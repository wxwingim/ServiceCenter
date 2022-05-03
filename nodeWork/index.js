const express = require('express');

const app = express();

app.get('/', function(req, res) {
    res.send("<h1>Main page</h1>")
});

app.get('/about', function(req, res) {
    res.send("<h1>About</h1>")
});

app.get('/contact', function(req, res) {
    res.send("<h1>Contact</h1>")
});

app.listen(8080);