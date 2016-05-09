import { Component, OnInit } from 'angular2/core'
import { IProduct } from './product'
import { ProductService } from './product.service'
import { ProductFilterPipe } from './product-filter.pipe'
import { StarComponent } from '../shared/star.component'
import { Observable } from 'rxjs/Observable'
import { ROUTER_DIRECTIVES } from 'angular2/router' 

@Component({
    selector: 'pm-products',
    templateUrl: 'app/products/product-list.component.html',
    styleUrls: ['app/products/product-list.component.css'],
    pipes: [ProductFilterPipe],
    directives: [StarComponent,ROUTER_DIRECTIVES]
})
export class ProductListComponent implements OnInit {
      
    pageTitle:String="Product Listings";
    imageWidth:number=50;
    imageMargin:number=2;
    showImage:boolean=false;
    listFilter:string="";
    products: IProduct[];

    constructor(private _productService : ProductService) {} //typesript shorthand for creating and internal private var

    toggleImage(): void {
        this.showImage = !this.showImage;    
    }

    ngOnInit() : void{
        //Start loading data
        this._productService.getProducts().subscribe(products => this.products = products,
            error => this.pageTitle = <any>error);
    }

    onRatingClicked(message: string) : void {        
        this.pageTitle = 'Product List: ' + message;
    }
}