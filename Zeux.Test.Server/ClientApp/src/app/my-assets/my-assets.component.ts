import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-my-assets',
  templateUrl: './my-assets.component.html',
  styleUrls: ['./my-assets.component.scss']
})
export class MyAssetsComponent implements OnInit {

  private type: string;
  private assetTypes: Array<AssetType>;
  private assets: Array<Asset>;
  private assetsState:Array<Asset>;

  constructor(private route: ActivatedRoute,
    private http: HttpClient,
    private router: Router) { }
    private httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

  ngOnInit() {
    this.type = this.route.snapshot.params.type;
    this.loadAssets();

    const uriAssetTypes = '/api/asset/GetTypes';

    this.http.get<Array<AssetType>>(uriAssetTypes, this.httpOptions)
    .subscribe((dataAssetTypes: Array<AssetType>) => {
        this.assetTypes = dataAssetTypes;
      });

    this.router.events
    .subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.applyFilter();
    }});
  }

  applyFilter() {
    var routeTypeParam = this.route.snapshot.params.type.toLowerCase();
    if(routeTypeParam == 'all'){
      this.assetsState = this.assets;
    }
    else 
      this.assetsState = this.assets.filter(x=>x.type.name.toLowerCase() == this.route.snapshot.params.type.toLowerCase())
  }

  loadAssets(){
    const uriAsset = '/api/asset/Get/all';
    this.http.get<Array<Asset>>(uriAsset, this.httpOptions)
    .subscribe((dataAssets: Array<Asset>) => {
          this.assets = dataAssets;
          this.assetsState = dataAssets;
          this.applyFilter();
      });
  }
}

export class AssetType {
  constructor(
    public id: number,
    public name: string) { }
}

export class Asset {
  constructor(
    public id: number,
    public name: string,
    public percent: number,
    public sum: number,
    public type: AssetType,
    public assetTypeName: string) { }
}
