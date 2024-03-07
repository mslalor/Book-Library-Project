const {Client} = require('pg')

const client = new Client ({
    host: "localhost",
    user: "postgres",
    port: 5432,
    password: "makm18910",
    database: "personallibrary"
})

client.connect();

client.query('Select * from user_table', (err, res)=> {
    if (!err) {
        console.log(res.rows);
    } else {
        console.log(err.message);
    }
    client.end;
})