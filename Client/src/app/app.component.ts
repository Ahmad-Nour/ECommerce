import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/Pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'E-Commerce';
  products: IProduct[] = [];
  constructor(private http :HttpClient) { }

  ngOnInit(): void {
    
    this.http.get('http://localhost:5000/products?PageIndex=1').subscribe((response: any) =>{
      this.products =response.data;
    }, error =>{
        console.log(error);
    }
    );

  }

}
