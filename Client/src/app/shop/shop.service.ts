import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/Pagination';
import { IProductBrands } from '../shared/models/ProductBrands';
import { IProductTypes } from '../shared/models/ProductTypes';
import {map} from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl :string ='http://localhost:5000/';
  constructor(private http :HttpClient) { }

  getProduct(shopParams : ShopParams){

    let params = new HttpParams();

    if(shopParams.brandId !==0){
      params =params.append('brandId' , shopParams.brandId.toString());
    }

    if(shopParams.typeId !==0){
      params =params.append('typeId' , shopParams.typeId.toString());
    }

    if(shopParams.search){
      params =params.append('search' , shopParams.search);
    }

    params =params.append('sort' , shopParams.sort);
    params =params.append('pageIndex' , shopParams.pageNumber.toString());
    params =params.append('pageSize' , shopParams.pageSize.toString());

    return this.http.get<IPagination |any>(this.baseUrl + 'products' , {observe :'response' ,params})
    .pipe(
      map(response =>{
        return response.body;
      })
    );
  }

  getProductById(id : any){
    return this.http.get<IProduct>(this.baseUrl +'products/'+ id);
  }

  getProductType(){
    return this.http.get<IProductTypes>(this.baseUrl  +'Products/types');
  }

  getProductBrands(){
    return this.http.get<IProductBrands>(this.baseUrl  +'Products/brands');
  }
}
