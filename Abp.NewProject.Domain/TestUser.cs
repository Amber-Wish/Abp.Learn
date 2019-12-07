using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Abp.NewProject.Domain
{
    public class TestUser:Entity<long>
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }
    }
}