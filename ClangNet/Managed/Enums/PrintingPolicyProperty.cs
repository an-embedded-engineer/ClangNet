using System;

namespace ClangNet
{
    /// <summary>
    /// Printing Policy Property
    /// </summary>
    /// <remarks>
    /// Properties for the printing policy.
    /// See <c>clang::PrintingPolicy</c> for more information.
    /// </remarks>
    public enum PrintingPolicyProperty
    {
        /// <summary>
        /// Indentation
        /// </summary>
        Indentation,

        /// <summary>
        /// Suppress Specifiers
        /// </summary>
        SuppressSpecifiers,

        /// <summary>
        /// Suppress Targ Keyword
        /// </summary>
        SuppressTagKeyword,

        /// <summary>
        /// Include Tag Definition
        /// </summary>
        IncludeTagDefinition,

        /// <summary>
        /// Suppress Scope
        /// </summary>
        SuppressScope,

        /// <summary>
        /// Suppress Unwritten Scope
        /// </summary>
        SuppressUnwrittenScope,

        /// <summary>
        /// Suppress Initializers
        /// </summary>
        SuppressInitializers,

        /// <summary>
        /// Constant Array Size As Written
        /// </summary>
        ConstantArraySizeAsWritten,

        /// <summary>
        /// Anonymous Tag Locations
        /// </summary>
        AnonymousTagLocations,

        /// <summary>
        /// Supress Strong Lifetime
        /// </summary>
        SuppressStrongLifetime,

        /// <summary>
        /// Suppress Lifetime Qualifiers
        /// </summary>
        SuppressLifetimeQualifiers,

        /// <summary>
        /// Suppress Template Args In C++ Constructors
        /// </summary>
        SuppressTemplateArgsInCXXConstructors,

        /// <summary>
        /// Bool
        /// </summary>
        Bool,

        /// <summary>
        /// Restrict
        /// </summary>
        Restrict,

        /// <summary>
        /// Align Of
        /// </summary>
        Alignof,

        /// <summary>
        /// Underscore Align Of
        /// </summary>
        UnderscoreAlignof,

        /// <summary>
        /// Use Void For Zero Parameters
        /// </summary>
        UseVoidForZeroParams,

        /// <summary>
        /// Terse Output
        /// </summary>
        TerseOutput,

        /// <summary>
        /// Polish For Declaration
        /// </summary>
        PolishForDeclaration,

        /// <summary>
        /// Half
        /// </summary>
        Half,

        /// <summary>
        /// MS Wide Character
        /// </summary>
        MSWChar,

        /// <summary>
        /// Include New Lines
        /// </summary>
        IncludeNewlines,

        /// <summary>
        /// MSVC Formatting
        /// </summary>
        MSVCFormatting,

        /// <summary>
        /// Constants As Written
        /// </summary>
        ConstantsAsWritten,

        /// <summary>
        /// Suppress Implicit Base
        /// </summary>
        SuppressImplicitBase,

        /// <summary>
        /// Fully Qualified Name
        /// </summary>
        FullyQualifiedName,

        /// <summary>
        /// Last Property
        /// </summary>
        LastProperty = FullyQualifiedName,
    }
}
