using Giving__FinalProcekt_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giving__FinalProcekt_.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutOption> AboutOptions { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<CauseGallery> CauseGalleries { get; set; }
        public DbSet<Comment1> Comments { get; set; }
        public DbSet<CommentPost1> CommentPosts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Donate> Donates { get; set; }
        public DbSet<DonatePrice> DonatePrices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<HappyFaces> HappyFaces { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<TagEvent> TagEvents { get; set; }
        public DbSet<TagToEvent> TagToEvents { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

    }
}
