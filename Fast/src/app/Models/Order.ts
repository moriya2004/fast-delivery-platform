export class Order{
    id:number=0;
    customerId:number=0;
    employeeId:number=0;
    date!:Date;
    toAddress:string="";
    status:boolean=false
}