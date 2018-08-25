namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdayInCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE customers SET Birthday = '1990/5/19' WHERE name = 'Mai Van Khanh'");
            Sql("UPDATE customers SET Birthday = '1990/6/16' WHERE name = 'Tran Van Tuan'");
        }
        
        public override void Down()
        {
        }
    }
}
