import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  SERVER_URL = "https://localhost:7086";
  constructor(private httpClient: HttpClient) { 

    public getProdutos(){
      return this.httpClient.get('${SERVER_URL}/produtos');
    }



  }
}
