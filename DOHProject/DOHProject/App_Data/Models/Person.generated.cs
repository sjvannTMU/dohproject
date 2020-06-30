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
	/// <summary>Person</summary>
	[PublishedModel("person")]
	public partial class Person : PublishedElementModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const string ModelTypeAlias = "person";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Person, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Person(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Address
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("address")]
		public global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.Address> Address => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.Address>>("address");

		///<summary>
		/// BirthDate
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("birthDate")]
		public global::System.DateTime BirthDate => this.Value<global::System.DateTime>("birthDate");

		///<summary>
		/// Gender
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("gender")]
		public global::Umbraco.Core.Models.PublishedContent.IPublishedContent Gender => this.Value<global::Umbraco.Core.Models.PublishedContent.IPublishedContent>("gender");

		///<summary>
		/// Identifier
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("identifier")]
		public global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.Identifier> Identifier => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.Identifier>>("identifier");

		///<summary>
		/// Name
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("personName")]
		public global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.HumanName> PersonName => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.HumanName>>("personName");

		///<summary>
		/// Telecom
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.1")]
		[ImplementPropertyType("telecom")]
		public global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.ContactPoint> Telecom => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.ContactPoint>>("telecom");
	}
}
