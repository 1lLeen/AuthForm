using AuthForm.Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Infrastucture.Config
{
    public class BaseConfiguration<TModel>:IEntityTypeConfiguration<TModel> where TModel : BaseModel
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
        public static void InitDefaultDateColumns(EntityTypeBuilder<TModel> builder)
        {
            builder.Property(x => x.CreatedTime)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

            builder.Property(x => x.UpdatedTime)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }

    }
}
