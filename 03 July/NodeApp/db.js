const mongoose = require('mongoose');

const mongoURI = 'mongodb://my-mongodb:27017/mydatabase'; // Replace with your database name

mongoose.connect(mongoURI)
.then(() => console.log('MongoDB connected successfully'))
.catch(err => console.error('Error connecting to MongoDB:', err));

module.exports = mongoose; // Export the mongoose connection for use in other files
