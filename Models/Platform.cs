using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GraphQL_dotNet.GraphQL;

namespace GraphQL_dotNet.Models {
	public class Platform {
		[Key] public int Id { get; set; }
		[Required] public string Name { get; set; }

		public string LicenseKey { get; set; }
		public ICollection<Command> Commands { get; set; } = new List<Command>();
	}
}