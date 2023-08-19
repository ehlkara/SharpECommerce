import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Sharp';
  products: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:7001/api/products?pageSize=50').subscribe({
      next: (response: any) => this.products = response.data, // what to do next
      error: error => console.log(error), // what to do if there is an error
      complete: () => {
        console.log('request completed');
        console.log('extra statement');
      }
    })
  }
}
