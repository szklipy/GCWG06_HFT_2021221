let employees = [];

getdata();

async function getdata() {
    await fetch('http://localhost:16099/employee')
        .then(x => x.json())
        .then(y => {
            employees = y;
            //console.log(employees);
            display();
        });

}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    employees.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.employee_id + "</td><td>"
            + t.name + "</td><td>"
            + t.salary + "</td><td>"
            + `<button type="buttin" onclick="remove(${t.employee_id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:16099/employee/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('employeeName').value;
    let salary = document.getElementById('employeeSalary').value;
    fetch('http://localhost:16099/employee', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, salary: salary}),})
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', error); });
        
}