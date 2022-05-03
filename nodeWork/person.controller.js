const db = require('../db')

class PersonController{
    async createPerson(req, res){
        const{user_name, user_age} = req.body
        const newPerson = await db.query('INSERT INTO person (user_name, user_age) VALUES ($1, $2) RETURNING *', [user_name, user_age])
        res.json(newPerson.rows[0])
    }
}