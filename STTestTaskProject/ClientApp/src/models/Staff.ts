import {Department} from "./Department";
import {Position} from "./Position";

export class Staff {
  id: number;
  name: string;
  surname: string;
  lastname: string;
  creationDate: Date;
  lastEditDate: Date;
  employmentDate: Date;
  position: Position;
  department: Department;
  positionId: number;
  departmentId: number;
  constructor() {
    this.id = 0;
  }
}

