﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SaaSRMS.Migrations
{
    public partial class Changestotherestaurantsubscriptionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantSubscriptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantSubscriptions_RestaurantId",
                table: "RestaurantSubscriptions",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantSubscriptions_Restaurants_RestaurantId",
                table: "RestaurantSubscriptions",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantSubscriptions_Restaurants_RestaurantId",
                table: "RestaurantSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantSubscriptions_RestaurantId",
                table: "RestaurantSubscriptions");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantSubscriptions");
        }
    }
}
