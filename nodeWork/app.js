const express = require('express');

const personRouter = require('./routes/person.routes')

const PORT = process.env.PORT || 8080

const app = express();

app.use(express.json())

app.use("/api", personRouter)

app.get("/", function(req, res){
    res.redirect('/api/person');
});

app.get("/api/person", function(req, res){
    res.sendFile(__dirname + "/index.html");
});

// const jsonParser = express.json();

// app.post("/user", jsonParser, function(req,res){
//     console.log(req.body);
//     if(!req.body) return res.sendStatus(400);

//     res.json(req.body);
// });



app.listen(PORT, ()=>console.log("Сервер запущен"));