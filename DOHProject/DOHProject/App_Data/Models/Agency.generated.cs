//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.6.1
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
	/// <summary>Agency</summary>
	[PublishedModel("agency")]
	public partial class Agency : PublishedContentModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const string ModelTypeAlias = "agency";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Agency, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Agency(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Accreditation Type: 評鑑類別
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("accreditationType")]
		public string AccreditationType => this.Value<string>("accreditationType");

		///<summary>
		/// Address: 機構地址
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("address")]
		public global::Umbraco.Web.PublishedModels.AddressElement Address => this.Value<global::Umbraco.Web.PublishedModels.AddressElement>("address");

		///<summary>
		/// Agency Alias: 機構簡稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("agencyAlias")]
		public string AgencyAlias => this.Value<string>("agencyAlias");

		///<summary>
		/// Agency Author: 機構權屬別
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("agencyAuthor")]
		public string AgencyAuthor => this.Value<string>("agencyAuthor");

		///<summary>
		/// Agency ID: 機構代碼-健保
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("agencyID")]
		public string AgencyID => this.Value<string>("agencyID");

		///<summary>
		/// Agency Name: 機構名稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("agencyName")]
		public string AgencyName => this.Value<string>("agencyName");

		///<summary>
		/// Agency Status: 機構狀態
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("agencyStatus")]
		public string AgencyStatus => this.Value<string>("agencyStatus");

		///<summary>
		/// Agency Type: 經營型態
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("agencyType")]
		public string AgencyType => this.Value<string>("agencyType");

		///<summary>
		/// Is HQ: 是否為本院
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("isHQ")]
		public bool IsHQ => this.Value<bool>("isHQ");

		///<summary>
		/// TEL: 機構通訊
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("tEL")]
		public global::Umbraco.Web.PublishedModels.TelElement TEL => this.Value<global::Umbraco.Web.PublishedModels.TelElement>("tEL");
	}
}
