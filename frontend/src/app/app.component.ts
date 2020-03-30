import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  model: any;
  title = 'frontend';
constructor(private http: HttpClient){
  this.getHeroes().subscribe(data=>this.model = data.name)
}

getHeroes(){
  return this.http.get<any>("http://localhost:5000/api/values") ;

}

}
