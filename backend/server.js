const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const sqlite3 = require('sqlite3').verbose();

const app = express();
const port = 3000;

// Middleware
app.use(cors());
app.use(bodyParser.json());

// Connect to the SQLite database
const db = new sqlite3.Database('hotel.db', (err) => {
  if (err) {
    console.error("Error connecting to the database:", err.message);
  } else {
    console.log("Connected to the SQLite database.");
  }
});

// POST endpoint for booking submissions
app.post('/bookings', (req, res) => {
  const { name, contact, email, checkInDate, checkOutDate, guests, roomType, roomCount, specialRequests } = req.body;

  const query = `
    INSERT INTO bookings (name, contact, email, checkInDate, checkOutDate, guests, roomType, roomCount, specialRequests)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?);
  `;

  db.run(query, [name, contact, email, checkInDate, checkOutDate, guests, roomType, roomCount, specialRequests], function (err) {
    if (err) {
      console.error("Error saving booking:", err.message);
      res.status(500).json({ error: "Failed to save booking." });
    } else {
      console.log("Booking saved with ID:", this.lastID);
      res.status(201).json({ message: 'Booking confirmed!', bookingId: this.lastID });
    }
  });
});

// GET endpoint to fetch all bookings (for admin purposes)
app.get('/bookings', (req, res) => {
  const query = `SELECT * FROM bookings;`;

  db.all(query, [], (err, rows) => {
    if (err) {
      console.error("Error fetching bookings:", err.message);
      res.status(500).json({ error: "Failed to fetch bookings." });
    } else {
      res.status(200).json(rows);
    }
  });
});

// DELETE endpoint to delete a booking
app.delete('/bookings/:id', (req, res) => {
  const { id } = req.params;

  const query = `DELETE FROM bookings WHERE id = ?;`;

  db.run(query, [id], function (err) {
    if (err) {
      console.error("Error deleting booking:", err.message);
      res.status(500).json({ error: "Failed to delete booking." });
    } else {
      console.log("Booking deleted with ID:", id);
      res.status(200).json({ message: 'Booking deleted successfully!' });
    }
  });
});

// PUT endpoint to update a booking
app.put('/bookings/:id', (req, res) => {
  const { id } = req.params;
  const { name, contact, email, checkInDate, checkOutDate, guests, roomType, roomCount, specialRequests } = req.body;

  const query = `
    UPDATE bookings
    SET name = ?, contact = ?, email = ?, checkInDate = ?, checkOutDate = ?, guests = ?, roomType = ?, roomCount = ?, specialRequests = ?
    WHERE id = ?;
  `;

  db.run(query, [name, contact, email, checkInDate, checkOutDate, guests, roomType, roomCount, specialRequests, id], function (err) {
    if (err) {
      console.error("Error updating booking:", err.message);
      res.status(500).json({ error: "Failed to update booking." });
    } else {
      console.log("Booking updated with ID:", id);
      res.status(200).json({ message: 'Booking updated successfully!' });
    }
  });
});

// Start the server
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});