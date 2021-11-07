using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
	class GenerateTicket
	{
		public static void CreateTicket(FlightPlan ticket, CustomerAccount customer)
		{
			string html = "<!DOCTYPE html>";
			html += "<html>';";
			html += "<head>";
			html += "<title> FLIGHTPLANNER | TICKET </title>";
			html += "<meta name = 'description' content = 'This is the description'>";


			html += " <link rel='stylesheet' href='TicketResources/styles.css'>";
			html += "</head>";


			html += "<body>";

			html += "  <header class='main-header'>";
			html += "	<h1 class='band-name band-name-large'>FLIGHTPLANNER &#9992</h1>";
			html += "<h2 style = 'color:rgb(152, 200, 223); text-align: center'> Lets discover the world together!</h2>";
			html += "</header>";

			html += "<section class='container content-section'>";
			html += "<h2 class='section-header'>HERE IS YOUR TICKET</h2>";
			html += "	<div class='shop-items'>";
			html += "		<div class='shop-item'>";
			html += "			<span class='shop-item-title'>Our EXTRAS</span>";
			html += "			<span style = 'color: cadetblue;' class='shop-item-title'>First Class MEALS</span>";
			html += "			<img class='shop-item-image' src='TicketResources/Images/meal.jfif'>";
			html += "			<div class='shop-item-details'>";
			html += "				<span class='shop-item-price'>$130</span>";
			html += "				<span style = 'color: rgb(36, 41, 41)'> Buy on plane</span>";
			html += "			</div>";
			html += "		</div>";
			html += "		<div style = 'background-color: rgb(214, 198, 198);' class='shop-item1'>";
			html += "			<span class='shop-item-title'>FLIGHT Information</span>";
			html += "			<span style = 'color: black; font-size: 1.2em; font-weight: 600;'> Airport from:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> " + ticket.From.Name + ", " + ticket.From.Country + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600'> Airport to:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> " + ticket.To.Name + ", " + ticket.To.Country + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600' > Date:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> " + $"{ticket.Date.Year}-{ticket.Date.Month}-{ticket.Date.Day}" + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600'> Airline:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> " + ticket.Airline + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600'> Flight Name:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> " + ticket.PlaneName + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600'> Plane type:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> " + ticket.PlaneType + "</span><br>";
			html += "			<span style = 'color: black; font-size: 1.2em; font-weight: 600'> Ticket Price:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'>$" + ticket.TicketPrice + "</span><br>";

			html += "		</div>";
			html += "		<div class='shop-item'>";
			html += "			<span style = 'color: cadetblue;' class='shop-item-title'>First Class LAMPS</span>";
			html += "			<img class='shop-item-image' src='TicketResources/Images/lamps.jfif'>";
			html += "			<div class='shop-item-details'>";
			html += "				<span class='shop-item-price'>from $1600</span>";
			html += "				<span style = 'color: rgb(36, 41, 41)'> Buy on plane</span> ";
			html += "			</div>";
			html += "		</div>";
			html += "		<div style = 'background-color: rgb(214, 198, 198);' class='shop-item1'>";
			html += "			<span class='shop-item-title'>PASSENGER information</span>";
			html += "			<span style = 'color: black; font-size: 1.2em; font-weight: 600'> First Name:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;' > " + customer.FirstName + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600'> Last Name:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;' > " + customer.LastName + " </span><br>";
			html += "			<span style= 'color: black; font-size: 1.2em; font-weight: 600'> Seat Number:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;' > 31 A</span><br>";
			html += "			<span style = 'color: black; font-size: 1.2em; font-weight: 600'> Entrance to:</span>";
			html += "			<span style = 'color: black; font-size: 1.5em;'> Back door</span><br>";

			html += "		</div>";
			html += "	</div>";
			html += "</section>";
			html += "<section class='container content-section'>";
			html += "	<h2 class='section-header'>Our policy</h2>";
			html += "	<div>";
			html += "		<span>Your baggage allowance depends on your ticket type. ";
			html += "			All carry-on baggage must be within the size and weight";
			html += "				limits and fit under the seat in front of you.Coats and jackets";
			html += "				can be stowed in the overhead compartment.";
			html += "			Duty-free and airport purchases count as part of your carry-on.</span><br>";
			html += "	</div>";
			html += "</section>";

			html += "<footer class='main-footer'>";
			html += "	<div class='container main-footer-container'>";
			html += "		<h3 style = 'color: rgb(85, 127, 146);' class='band-name band-name-footer'>FLIGHTPLANNER &#9992</h3>";
			html += "		<ul class='nav footer-nav'>";
			html += "			<li style = 'color:rgb(64, 96, 97);'> Follow us for inspiration</li>";
			html += "			<li>";
			html += "			<a href = 'https://www.youtube.com' target='_blank'>";
			html += "				<img style = 'height: 50px; width: 50px;'; src='TicketResources/Images/Youtube.png'>";
			html += "			</a>";
			html += "			</li>";
			html += "			<li>";
			html += "			<a href = 'https://www.facebook.com' target='_blank'>";
			html += "			<img style = 'height: 50px; width: 50px;'; src='TicketResources/Images/Facebook.png'>";
			html += "			</a>";
			html += "			</li>";
			
			html += "		</ul>";
			html += "	</div>";
			html += "</footer>";
			html += "	</body>";

			html += "</html>";

			File.WriteAllText(@"Files\Ticket.html", html);
		}
    }
}
