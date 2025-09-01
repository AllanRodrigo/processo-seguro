import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Seguros {
  cpf: number;
  mediaSeguros: number;
}

@Injectable({
  providedIn: 'root'
})
export class SeguroAllanService {
  private backendUrl: string = 'http://localhost:5000/api/Seguros'; // URL do backend

  constructor(private http: HttpClient) { }

  getRelatorioSeguros(): Observable<Seguros[]> {
    // Faz uma requisição HTTP GET para buscar o relatório de media de seguros
    return this.http.get<Seguros[]>(`${this.backendUrl}/relatorio`);
  }
}
