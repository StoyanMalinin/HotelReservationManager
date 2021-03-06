// <auto-generated />
using System;
using HotelReservationsManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelReservationsManager.Migrations
{
    [DbContext(typeof(HotelDb))]
    partial class HotelDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelReservationsManager.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdult")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("HotelReservationsManager.Reservation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("allInclusive")
                        .HasColumnType("bit");

                    b.Property<bool>("breakfast")
                        .HasColumnType("bit");

                    b.Property<double>("cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("dateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("roomid")
                        .HasColumnType("int");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roomid");

                    b.HasIndex("userid");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("HotelReservationsManager.ReservationClientLinker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("clientid")
                        .HasColumnType("int");

                    b.Property<int?>("reservationid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clientid");

                    b.HasIndex("reservationid");

                    b.ToTable("linkers");
                });

            modelBuilder.Entity("HotelReservationsManager.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<bool>("isFree")
                        .HasColumnType("bit");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<double>("priceAdult")
                        .HasColumnType("float");

                    b.Property<double>("priceChild")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("HotelReservationsManager.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EGN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dismisalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("recruitmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("secondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thirdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("HotelReservationsManager.Reservation", b =>
                {
                    b.HasOne("HotelReservationsManager.Room", "room")
                        .WithMany()
                        .HasForeignKey("roomid");

                    b.HasOne("HotelReservationsManager.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelReservationsManager.ReservationClientLinker", b =>
                {
                    b.HasOne("HotelReservationsManager.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientid");

                    b.HasOne("HotelReservationsManager.Reservation", "reservation")
                        .WithMany("clients")
                        .HasForeignKey("reservationid");

                    b.Navigation("client");

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("HotelReservationsManager.Reservation", b =>
                {
                    b.Navigation("clients");
                });
#pragma warning restore 612, 618
        }
    }
}
