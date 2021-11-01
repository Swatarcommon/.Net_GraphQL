using System.ComponentModel.DataAnnotations;
using GraphQL_dotNet.Models;

namespace GraphQL_dotNet.GraphQL {
	public class Command {
		[Key] public int Id { get; set; }
		[Required] public string HowTo { get; set; }
		[Required] public string CommandLine { get; set; }
		[Required] public int PlatformId { get; set; }
		public Platform Platform { get; set; }
	}
}