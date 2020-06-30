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
	/// <summary>Principal</summary>
	[PublishedModel("principal")]
	public partial class Principal : PublishedContentModel, IAD, IIdentify, IXPN, IXTN
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const string ModelTypeAlias = "principal";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Principal, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Principal(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Is Part time: 是兼任負責人
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("isPartTime")]
		public bool IsPartTime => this.Value<bool>("isPartTime");

		///<summary>
		/// Address Type: 地址類別
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("addressType")]
		public global::Umbraco.Core.Models.PublishedContent.IPublishedContent AddressType => global::Umbraco.Web.PublishedModels.AD.GetAddressType(this);

		///<summary>
		/// AreaCode: 縣市代碼
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("areaCode")]
		public string AreaCode => global::Umbraco.Web.PublishedModels.AD.GetAreaCode(this);

		///<summary>
		/// Area Name: 縣市名稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("areaName")]
		public string AreaName => global::Umbraco.Web.PublishedModels.AD.GetAreaName(this);

		///<summary>
		/// Stress Address: 地址-街道名稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("stressAddress")]
		public string StressAddress => global::Umbraco.Web.PublishedModels.AD.GetStressAddress(this);

		///<summary>
		/// Zip Code: 鄉鎮市區Zip碼
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("zipCode")]
		public string ZipCode => global::Umbraco.Web.PublishedModels.AD.GetZipCode(this);

		///<summary>
		/// Zip Name: 鄉鎮市區名稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("zipName")]
		public string ZipName => global::Umbraco.Web.PublishedModels.AD.GetZipName(this);

		///<summary>
		/// Birthday: 生日
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("birthday")]
		public global::System.DateTime Birthday => global::Umbraco.Web.PublishedModels.Identify.GetBirthday(this);

		///<summary>
		/// Gender: 性別
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("gender")]
		public int Gender => global::Umbraco.Web.PublishedModels.Identify.GetGender(this);

		///<summary>
		/// SID: 身份證號
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("sID")]
		public string SID => global::Umbraco.Web.PublishedModels.Identify.GetSID(this);

		///<summary>
		/// Family Name: 姓
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("familyName")]
		public string FamilyName => global::Umbraco.Web.PublishedModels.XPN.GetFamilyName(this);

		///<summary>
		/// Full Name: 全名
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("fullName")]
		public string FullName => global::Umbraco.Web.PublishedModels.XPN.GetFullName(this);

		///<summary>
		/// Given Name: 名
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("givenName")]
		public string GivenName => global::Umbraco.Web.PublishedModels.XPN.GetGivenName(this);

		///<summary>
		/// Nick Name: 暱稱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("nickName")]
		public string NickName => global::Umbraco.Web.PublishedModels.XPN.GetNickName(this);

		///<summary>
		/// Country Code: 國碼
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("countryCode")]
		public string CountryCode => global::Umbraco.Web.PublishedModels.XTN.GetCountryCode(this);

		///<summary>
		/// Email: 電子信箱
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("email")]
		public string Email => global::Umbraco.Web.PublishedModels.XTN.GetEmail(this);

		///<summary>
		/// Extension: 分機
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("extension")]
		public string Extension => global::Umbraco.Web.PublishedModels.XTN.GetExtension(this);

		///<summary>
		/// Mobile: 手機號碼
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("mobile")]
		public string Mobile => global::Umbraco.Web.PublishedModels.XTN.GetMobile(this);

		///<summary>
		/// Phone Area Code: 區碼
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("phoneAreaCode")]
		public string PhoneAreaCode => global::Umbraco.Web.PublishedModels.XTN.GetPhoneAreaCode(this);

		///<summary>
		/// Telephone Number: 電話號碼
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("telephoneNumber")]
		public string TelephoneNumber => global::Umbraco.Web.PublishedModels.XTN.GetTelephoneNumber(this);

		///<summary>
		/// Web Site: 網站
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("webSite")]
		public string WebSite => global::Umbraco.Web.PublishedModels.XTN.GetWebSite(this);
	}
}