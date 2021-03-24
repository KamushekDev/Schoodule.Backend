using System;

namespace Schoodule.Business.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class SwaggerSchemaIdAttribute : Attribute
	{
		public string SchemaId { get; }

		public SwaggerSchemaIdAttribute(string schemaId)
		{
			SchemaId = schemaId;
		}
	}
}