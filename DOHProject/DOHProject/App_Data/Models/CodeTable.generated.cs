//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.6.3
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Code Table</summary>
	[PublishedModel("codeTable")]
	public partial class CodeTable : PublishedContentModel, ICodeSystem, IUsingStatus
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const string ModelTypeAlias = "codeTable";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<CodeTable, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public CodeTable(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Code System ID: 編碼系統之ID
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("codeSystemID")]
		public string CodeSystemID => global::Umbraco.Web.PublishedModels.CodeSystem.GetCodeSystemID(this);

		///<summary>
		/// Code System Name: 編碼系統名稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("codeSystemName")]
		public string CodeSystemName => global::Umbraco.Web.PublishedModels.CodeSystem.GetCodeSystemName(this);

		///<summary>
		/// Code System OID: 編碼系統OID
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("codeSystemOID")]
		public string CodeSystemOid => global::Umbraco.Web.PublishedModels.CodeSystem.GetCodeSystemOid(this);

		///<summary>
		/// Code System Source: 編碼系統來源
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("codeSystemSource")]
		public string CodeSystemSource => global::Umbraco.Web.PublishedModels.CodeSystem.GetCodeSystemSource(this);

		///<summary>
		/// Code System URI: 編碼系統URI
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("codeSystemURI")]
		public string CodeSystemUri => global::Umbraco.Web.PublishedModels.CodeSystem.GetCodeSystemUri(this);

		///<summary>
		/// Is Active: 使用中
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("isActive")]
		public bool IsActive => global::Umbraco.Web.PublishedModels.UsingStatus.GetIsActive(this);

		///<summary>
		/// Is Expire: 過期
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("isExpire")]
		public bool IsExpire => global::Umbraco.Web.PublishedModels.UsingStatus.GetIsExpire(this);
	}
}
