# 1) Create a application that will take the Employee details(Name, DOB, Phone and E-Mail) 
#    from console, validate it and calculate age(Age should not taken from user)
#    The application should show menu to store the same in file. Option for saving should be text/excel/pdf. 
#    Optional implementation - > Bulk read and store in list from Excel file

import datetime
import xlsxwriter
from fpdf import FPDF

class Employee:

    def __init__(self,Name,Dob,Phone,Email):
        self.Name= Name
        self.Dob = Dob
        self.Phone = Phone
        self.Email = Email
        self.Age = self.Calculate_age(Dob)

    @staticmethod
    def Calculate_age(Dob):
        today = datetime.date.today()
        age = today.year - Dob.year
        print(age)
        return age

def getDob():
    while True:
        try:
            Dob = input("Enter Dob (like : YYYY-MM-DD): ")
            dobObject = datetime.datetime.strptime(Dob, "%Y-%m-%d")
            return dobObject
        except ValueError:
            print("OOps...! please check your dob input")

def GetDetailsFromConsole():
    name = input("Enter your name : ")
    Dob = getDob();
    Phone = input("Enter your Phone no: ")
    Email = input("Enter your email : ")
    # name = "kavin"
    # Dob = datetime.date.today();
    # Phone = 213453244
    # Email = "kavinkumar.prof@gmail.com"
    newEmployee = Employee(name,Dob,Phone,Email)
    return newEmployee;


def SelectFileType():
    while True:
        try:
            print("""Select File Type to store : 
                1. Pdf
                2. Excel Sheet
                3. Text file""")
            type = int(input("Enter your choice: "))
            if(type not in [1,2,3]):
                raise ValueError("Please enter correct choice... !");
            return type
        except ValueError:
            print(ValueError)

def pdf_output(employee):
    pdf = FPDF()
    pdf.add_page();
    pdf.set_font("Arial","B",16)
    pdf.write("hello")
    pdf.write(4,f"""Employee Details \n
        Employee Name : {employee.Name} \n
        Employee Dob : {employee.Dob} \n
        Employee Phone : {employee.Phone} \n
        Employee mailId : {employee.Email} \n
        Employee Age : {employee.Age}""")
    pdf.output("file.pdf")
    return 1;

def excel(employee):
    workbook = xlsxwriter.Workbook("Exceldata.xlsx")
    worksheet = workbook.add_worksheet()
    header_format = workbook.add_format({'bold': True}) 
    header = ["#", "Name", "Date of Birth", "Phone", "Email", "Age"]
    worksheet.write_row('A1', header, header_format)
    first_row = [1,employee.Name,employee.Dob,employee.Phone,employee.Email,employee.Age];
    worksheet.write_row('A2',first_row)
    workbook.close()


def main():
    print("Create new Employee");
    newEmployee = GetDetailsFromConsole();
    type = SelectFileType()
    if(type == 1):
        pdf_output(newEmployee);
    elif(type == 2):
        excel(newEmployee);

    print("Stored successfully");

main();
