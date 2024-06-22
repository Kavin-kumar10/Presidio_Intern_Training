//Encapsulation
class Student{
    constructor(Id,Name,Standard){
        this.Id = Id;
        this.Name = Name;
        this.Standard = Standard;
    }
    studentInfo(){
        console.log(`Name of the student ${this.Name} and studying in ${this.Standard} Standard`)
    }
    studying(){
        console.log("Started studying");
    }
}

//Inheritance
class RepresentativeOfStudents extends Student{
    constructor(Id,Name,Standard,RepresentativeGrade){
        super(Id,Name,Standard)
        this.RepresentativeGrade =RepresentativeGrade;
    }
    //Polymorpism
    studentInfo(){
        console.log(`Representative Name of the student ${this.Name} and studying in ${this.Standard} Standard with grade ${this.RepresentativeGrade}`)
        //Abstraction
        super.studying();
    }
}

let rep = new RepresentativeOfStudents(1,"Kavin","10th",1);
rep.studentInfo();