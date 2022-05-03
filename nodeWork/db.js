const Pool = require('pg').Pool
const pool = new Pool({
    user: 'work100022',
    password: 'Zf#t*#o~~dSchp9nRj4R',
    host: '45.10.244.15',
    port: '55532',
    database: 'work100022'
})

module.exports = pool