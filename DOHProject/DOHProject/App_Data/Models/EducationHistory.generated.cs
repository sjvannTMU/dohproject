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
	/// <summary>Education History</summary>
	[PublishedModel("educationHistory")]
	public partial class EducationHistory : PublishedContentModel, IEducationControl
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const string ModelTypeAlias = "educationHistory";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<EducationHistory, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public EducationHistory(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// DegLevel: 學歷級別
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("degLevel")]
		public string DegLevel => global::Umbraco.Web.PublishedModels.EducationControl.GetDegLevel(this);

		///<summary>
		/// DegYear: 畢業年度
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("degYear")]
		public string DegYear => global::Umbraco.Web.PublishedModels.EducationControl.GetDegYear(this);

		///<summary>
		/// School: 學校
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.3")]
		[ImplementPropertyType("school")]
		public global::Umbraco.Web.PublishedModels.SchoolElement School => global::Umbraco.Web.PublishedModels.EducationControl.GetSchool(this);
	}
}
