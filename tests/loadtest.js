import http from "k6/http";
import { sleep } from "k6";

export default function(){
    let employeesQuery = `
    query{
        employees{
          all{
            firstName
            lastName
            departmentId
          }
        }
      }
    `

    let headers = {
        "Content-Type": "application/json"
    };

    let response = http.post("http://localhost:5096/graphql",
        JSON.stringify({query: employeesQuery}),
        {headers: headers});
    
    if(response.status != 200){
        throw new Error("Failed to load employees");
    }
    sleep(0.3);
}