using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace CodeGuard.dotNetCore.Internals
{
    internal class MemberInfoReader<T>
    {
        #region Private Fields
        private static OpCode[] singleByteOpCodes;
        private readonly Func<T> _arg;
        #endregion Private Fields

        #region Internal Constructors

        internal MemberInfoReader(Func<T> arg)
        {
            this._arg = arg;
        }

        #endregion Internal Constructors

        #region Public Properties

        public static OpCode[] SingleByteOpCodes
        {
            get
            {
                if (singleByteOpCodes == null)
                {
                    LoadOpCodes();
                }
                return singleByteOpCodes;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public MemberInfo GetInfo()
        {
            byte[] methodBodyIlByteArray = GetMethodBodyIlByteArray();

            var argumentInfo = GetArgumentInfo(methodBodyIlByteArray);
            if (argumentInfo != null)
            {
                return GetMemberInfo(argumentInfo);
            }
            throw new InvalidExpressionException("Unable to get information about member");
        }

        #endregion Public Methods

        #region Private Methods

        private static ArgumentInfo GetArgumentInfo(byte[] methodBodyIlByteArray)
        {
            int position = 0;

            while (position < methodBodyIlByteArray.Length)
            {
                var code = GetOpCode(methodBodyIlByteArray, ref position);

                if (code.OperandType == OperandType.InlineField || code.OperandType == OperandType.InlineMethod)
                {
                    return new ArgumentInfo
                    {
                        OperandType = code.OperandType,
                        Token = ReadInt32(methodBodyIlByteArray, ref position)
                    };
                }

                position = MoveToNextPosition(position, code);
            }

            return null;
        }

        private static OpCode GetOpCode(byte[] methodBodyIlByteArray, ref int currentPosition)
        {
            ushort value = methodBodyIlByteArray[currentPosition++];
            return value != 0xfe ? SingleByteOpCodes[value] : OpCodes.Nop;
        }

        private static Type[] GetSubclassGenericTypes(Type toCheck)
        {
            var genericArgumentsTypes = new List<Type>();

            while (toCheck != null)
            {
                if (toCheck.IsGenericType)
                {
                    genericArgumentsTypes.AddRange(toCheck.GetGenericArguments());
                }

                toCheck = toCheck.BaseType;
            }

            return genericArgumentsTypes.ToArray();
        }

        private static void LoadOpCodes()
        {
            singleByteOpCodes = new OpCode[0x100];

            var opcodeFieldInfos = typeof(OpCodes).GetFields();

            foreach (var info1 in opcodeFieldInfos)
            {
                if (info1.FieldType == typeof(OpCode))
                {
                    var singleByteOpCode = (OpCode)info1.GetValue(null);

                    var singleByteOpcodeIndex = (ushort)singleByteOpCode.Value;

                    if (singleByteOpcodeIndex < 0x100)
                    {
                        singleByteOpCodes[singleByteOpcodeIndex] = singleByteOpCode;
                    }
                }
            }
        }

        private static int MoveToNextPosition(int position, OpCode code)
        {
            switch (code.OperandType)
            {
                case OperandType.InlineNone:
                    break;

                case OperandType.InlineI8:
                case OperandType.InlineR:
                    position += 8;
                    break;

                case OperandType.InlineField:
                case OperandType.InlineBrTarget:
                case OperandType.InlineMethod:
                case OperandType.InlineSig:
                case OperandType.InlineTok:
                case OperandType.InlineType:
                case OperandType.InlineI:
                case OperandType.InlineString:
                case OperandType.InlineSwitch:
                case OperandType.ShortInlineR:
                    position += 4;
                    break;

                case OperandType.InlineVar:
                    position += 2;
                    break;

                case OperandType.ShortInlineBrTarget:
                case OperandType.ShortInlineI:
                case OperandType.ShortInlineVar:
                    position++;
                    break;

                default:
                    throw new InvalidOperationException("Unknown operand type.");
            }
            return position;
        }

        private static int ReadInt32(byte[] il, ref int position)
        {
            return ((il[position++] | (il[position++] << 8)) | (il[position++] << 0x10)) | (il[position++] << 0x18);
        }

        private Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            Debug.WriteLine(args.Name);
            Console.WriteLine("load: {0}", args.Name);
            return Assembly.ReflectionOnlyLoad(args.Name);
        }

        private MemberInfo GetMemberInfo(ArgumentInfo argumentInfo)
        {
            MemberInfo memberInfo = null;

            if (argumentInfo.Token > 0)
            {
                var argType = _arg.Target.GetType();
                var genericTypeArguments = GetSubclassGenericTypes(argType);
                var genericMethodArguments = _arg.Method.GetGenericArguments();

                switch (argumentInfo.OperandType)
                {
                    case OperandType.InlineField:
                        memberInfo = argType.Module.ResolveField(argumentInfo.Token, genericTypeArguments,
                                                                 genericMethodArguments);
                        break;

                    case OperandType.InlineMethod:
                        memberInfo = argType.Module.ResolveMethod(argumentInfo.Token, genericTypeArguments,
                                                                  genericMethodArguments);
                        break;
                }
            }

            return memberInfo;
        }

        private byte[] GetMethodBodyIlByteArray()
        {
            var methodBody = _arg.Method.GetMethodBody();
            return methodBody.GetILAsByteArray();
        }

        #endregion Private Methods

        #region Private Classes

        private class ArgumentInfo
        {
            #region Public Fields
            public OperandType OperandType;
            public int Token;
            #endregion Public Fields
        }

        #endregion Private Classes
    }
}
