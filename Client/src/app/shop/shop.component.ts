import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrands } from '../shared/models/ProductBrands';
import { IProductTypes } from '../shared/models/ProductTypes';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  constructor(private shopService :ShopService) { }

  @ViewChild('search') searchTerm : ElementRef |any;
  products :IProduct[] =[];
  productsTypes :IProductTypes[] =[];
  productsBrands :IProductBrands[] =[];
  totalCount :number =0;
  sortOptions =[
    {name: 'Alphapetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];
  shopParams = new ShopParams();


  ngOnInit(): void {
    this.getProductTypes();
    this.getProductBrands();
    this.getProducts();
  }

  getProducts(){
    this.shopService.getProduct(this.shopParams).subscribe(response =>
    {
        this.products =response.data;
        this.shopParams.pageNumber =response.pageIndex;
        this.shopParams.pageSize =response.pageSize;
        this.totalCount =response.count;

    },
    (error) =>
    {
      console.log(error);
    }
    );
  }

  getProductBrands(){
    this.shopService.getProduct(this.shopParams).subscribe((response) =>
    {
      this.productsBrands =[{id :0 , name :'All'} , ...response.data];
    },
    (error) =>
    {
      console.log(error);
    }
    );
  }
  getProductTypes(){
    this.shopService.getProduct(this.shopParams).subscribe((response) =>
    {
      this.productsTypes =[{id :0 , name :'All'} , ...response.data];;
    },
    (error) =>
    {
      console.log(error);
    }
    );
  }

  onBrandSelected(brandId :number){
    this.shopParams.brandId =brandId;
    this.shopParams.pageNumber =1;
    this.getProducts();
  }

  onTypeSelected(TypeId :number){
    this.shopParams.typeId =TypeId;
    this.shopParams.pageNumber =1;
    this.getProducts();
  }

  onSortSelected(sort :any){
    this.shopParams.sort =sort.target.value.toString();
    this.shopParams.pageNumber =1;
    this.getProducts();
  }
  onPageChange(e :any){
    if(this.shopParams.pageNumber !== e){
      this.shopParams.pageNumber =e;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopParams.search =this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber =1;
    this.getProducts();
  }

  onReset(){
    this.searchTerm.nativeElement.value ='';
    this.shopParams = new ShopParams();
    this.getProducts();
  }

}
