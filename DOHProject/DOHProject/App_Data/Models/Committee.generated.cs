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
	/// <summary>Committee</summary>
	[PublishedModel("committee")]
	public partial class Committee : PublishedContentModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const string ModelTypeAlias = "committee";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Committee, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Committee(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Avoid Reasons: 迴避原因
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("avoidReasons")]
		public global::System.Collections.Generic.IEnumerable<string> AvoidReasons => this.Value<global::System.Collections.Generic.IEnumerable<string>>("avoidReasons");

		///<summary>
		/// Chinese Name: 中文姓名
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("chineseName")]
		public global::Umbraco.Web.PublishedModels.NameElement ChineseName => this.Value<global::Umbraco.Web.PublishedModels.NameElement>("chineseName");

		///<summary>
		/// Committee Type: 委員代表 1：學術 2：實務
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("committeeType")]
		public int CommitteeType => this.Value<int>("committeeType");

		///<summary>
		/// English Name: 英文姓名
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("englishName")]
		public global::Umbraco.Web.PublishedModels.NameElement EnglishName => this.Value<global::Umbraco.Web.PublishedModels.NameElement>("englishName");

		///<summary>
		/// Home Address: 住家地址
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("homeAddress")]
		public global::Umbraco.Web.PublishedModels.AddressElement HomeAddress => this.Value<global::Umbraco.Web.PublishedModels.AddressElement>("homeAddress");

		///<summary>
		/// Identity: 辨識資料
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("identity")]
		public global::Umbraco.Web.PublishedModels.IdentifyElement Identity => this.Value<global::Umbraco.Web.PublishedModels.IdentifyElement>("identity");

		///<summary>
		/// Occupation: 職業資訊
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("occupation")]
		public global::Umbraco.Web.PublishedModels.OccupationElement Occupation => this.Value<global::Umbraco.Web.PublishedModels.OccupationElement>("occupation");

		///<summary>
		/// Office Address: 辦公室地址
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("officeAddress")]
		public global::Umbraco.Web.PublishedModels.AddressElement OfficeAddress => this.Value<global::Umbraco.Web.PublishedModels.AddressElement>("officeAddress");

		///<summary>
		/// Resident Address: 戶籍地址
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("residentAddress")]
		public global::Umbraco.Web.PublishedModels.AddressElement ResidentAddress => this.Value<global::Umbraco.Web.PublishedModels.AddressElement>("residentAddress");

		///<summary>
		/// TEL Data: 聯絡方式
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("tELData")]
		public global::Umbraco.Web.PublishedModels.TelElement TEldata => this.Value<global::Umbraco.Web.PublishedModels.TelElement>("tELData");
	}
}