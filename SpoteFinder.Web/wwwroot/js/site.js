// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/parkingSpotHub")
    .build();

connection.start().catch(err => console.error('Error: ' + err));

connection.on("SpotAvailabilityChanged", (spotId, isAvailable) => {
    location.reload();
    //alert(`Spot ${spotId} availability updated: ${isAvailable ? "Available" : "Booked"}`);
});

connection.on("ReservationCreated", (reservation) => {
    alert(`New reservation created for spot ID: ${reservation.spotId}`);
});
