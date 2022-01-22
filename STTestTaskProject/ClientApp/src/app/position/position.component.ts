import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {Position} from "../../models/Position";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './position.component.html',
})
export class PositionComponent {
  public positions: Position[];
  public editPosition: Position = new Position();

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private router: Router, private modalService: NgbModal) {
  }

  ngOnInit() {
    this.http.get<Position[]>(this.baseUrl + 'position').subscribe(result => {
      this.positions = result;
    }, error => console.error(error));
  }

  public deletePosition(id: number): void {
    Swal.fire({
      title: 'Вы уверены, что хотите удалить запись?',
      text: "Вы не сможете восстановить этот файл!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Нет, оставить!',
      confirmButtonText: 'Да, удалить!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.delete(this.baseUrl + 'position/' + id).subscribe((res) => {
          this.ngOnInit();
        });
        Swal.fire(
          'Удалено!',
          'Ваша запись удалена.',
          'success'
        )
      }
    });
  }

  public managePosition(position: Position): void {
    if (position.id) {
      this.http.put<any>(this.baseUrl + 'position/'+position.id, position).subscribe((res) => {
        this.ngOnInit();
      })
    } else {
      this.http.post<any>(this.baseUrl + 'position/', position).subscribe((res) => {
        this.ngOnInit();
      })
    }
  }

  open(content, id: number) {
    if (id) {
      this.http.get<Position>(this.baseUrl + 'position/' + id).subscribe(result => {
        this.editPosition = result;
      }, error => console.error(error));
    }
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.editPosition = new Position();
    }, (reason) => {
      this.editPosition = new Position();
    });
  }

}

