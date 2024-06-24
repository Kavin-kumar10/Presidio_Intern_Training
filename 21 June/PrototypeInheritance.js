class Student{
    constructor(Name,Age,Grade){
        this.Name = Name;
        this.Age = Age;
        this.Grade= Grade;
    }
    GetName(){
        console.log(Name);
    }
}

class Representative{
    constructor(Name,Age,Grade){
        super(Name,Age,Grade)
    }
    GetGrade(){
        console.log(this.Grade);
    }
}

Representative.__proto__ = Student;
