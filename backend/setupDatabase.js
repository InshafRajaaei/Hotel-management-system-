const sqlite3 = require('sqlite3').verbose();

// Connect to or create the SQLite database
const db = new sqlite3.Database('hotel.db', (err) => {
  if (err) {
    console.error("Error connecting to the database:", err.message);
  } else {
    console.log("Connected to the SQLite database.");
  }
});

// Create the bookings table if it doesn't exist
const createBookingsTableQuery = `
  CREATE TABLE IF NOT EXISTS bookings (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    contact TEXT NOT NULL,
    email TEXT NOT NULL,
    checkInDate TEXT NOT NULL,
    checkOutDate TEXT NOT NULL,
    guests INTEGER NOT NULL,
    roomType TEXT NOT NULL,
    roomCount INTEGER NOT NULL,
    specialRequests TEXT,
    created_at TEXT DEFAULT CURRENT_TIMESTAMP
  );
`;

// Create the rooms table if it doesn't exist (optional)
const createRoomsTableQuery = `
  CREATE TABLE IF NOT EXISTS rooms (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    type TEXT NOT NULL,
    description TEXT,
    price REAL NOT NULL,
    image_url TEXT,
    created_at TEXT DEFAULT CURRENT_TIMESTAMP
  );
`;

// Execute the queries
db.serialize(() => {
  db.run(createBookingsTableQuery, (err) => {
    if (err) {
      console.error("Error creating bookings table:", err.message);
    } else {
      console.log("Bookings table created successfully or already exists.");
    }
  });

  db.run(createRoomsTableQuery, (err) => {
    if (err) {
      console.error("Error creating rooms table:", err.message);
    } else {
      console.log("Rooms table created successfully or already exists.");
    }
  });
});

// Close the database connection
db.close((err) => {
  if (err) {
    console.error("Error closing the database:", err.message);
  } else {
    console.log("Database connection closed.");
  }
});