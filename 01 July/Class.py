class Product:
    intro = "-- Adding new product --" #common for all instance

    #constructor
    def __init__(self,title,desc,price):
        print(self.intro)
        self.title = title
        self.desc = desc
        self.price = price

    #function
    def work(self,role):
        print("It is used for "+role)

#inheritance
class SpecialProduct(Product):
    #constructor
    def __init__(self, title, desc, price,offer):
        super().__init__(title, desc, price)
        self.offer = offer
    
    def work(self,role,special):
        print(f"It work with special offer of {special} in {role}")
    

Ball = Product('Soccor ball',"sports",250)
Ball.work('Playing')

Software = SpecialProduct("VScode","coding platform",250,15);

