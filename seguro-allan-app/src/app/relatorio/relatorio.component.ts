import { Component } from '@angular/core';
import { SeguroAllanService, Seguros } from '../services/seguro-allan.service';

@Component({
  selector: 'app-relatorio',
  templateUrl: './relatorio.component.html',
  styleUrls: ['./relatorio.component.scss']
})
export class RelatorioComponent {
  seguros: Seguros[] = [];

  constructor(private seguroService: SeguroAllanService){}

  ngOnInit(): void {
    this.getRelatorio();
  }

  // Método para obter o relatorio de seguros
  getRelatorio(): void {
    this.seguroService.getRelatorioSeguros().subscribe(
      data => {
        if (Array.isArray(data)) { // Validação para garantir que os dados são um array
          this.seguros = data; // Armazena o histórico de previsões na propriedade weatherHistory
          //this.updateDisplayedHistory(); // Atualiza as previsões exibidas na página atual
        } else {
          console.error('Formato de dados inválido', data);
        }
      },
      error => console.error('Erro ao buscar histórico de previsões do tempo', error)
    );
  }

}
