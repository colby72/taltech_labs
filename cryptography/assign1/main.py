from breakVigenere import *

crypto_file = open('cryptogram', "r", encoding="utf8")
cryptogram = crypto_file.read().strip()
#print(cryptogram)
crypto_file.close()

def double():
    print("Doubles in cryptogram :")
    print("-----------------------")
    freqs = freqDouble(cryptogram)
    for f in freqs:
        print(f[0], " => ", end="")
        for v in f[1]:
            print(v, " ", end="")
        print("\n")

def repeats():
    print("Repeated sequences :")
    print("--------------------")
    while True:
        print("Enter '0' to exit")
        n = int(input("Enter n > "))
        if n==0:
            break
        starts = testStart2(cryptogram, n)
        print(starts)

def parted():
    print("Eventual parts :")
    print("----------------")
    while True:
        print("Enter '0' to exit")
        n = int(input("Enter n > "))
        if n==0:
            break
        possible = splitStart2(cryptogram, n)
        for p in possible:
            print(p[0], " :: ", end="")
            for part in p[1]:
                #print(part, " => ", len(part)+len(p[0]))
                print(len(part)+len(p[0]), " ", end="")
            print("\n")

def analyse():
    print("Analyse cipher :")
    print("----------------")
    n = int(input("Enter key length > "))
    """groups = letterGroups(cryptogram, n)
    i = 1
    for g in groups:
        print("Letter group ", i, " => ", g)
        i += 1"""
    clusters = analyseClusters(cryptogram, n)
    i = 1
    for c in clusters:
        print("Letter group ", i, " => ", c)
        i += 1
        print("\n")

print(" 'D' > Search for double letters")
print(" 'R' > Search for repeated sequences")
print(" 'P' > Parts for repeated sequences")
print(" 'A' > Cipher analyse")
print(" 'X' > Quit")
command = ""
while command!="X":
    command = input("Enter command > ")
    if command=="D":
        double()
    elif command=="R":
        repeats()
    elif command=="P":
        parted()
    elif command=="A":
        analyse()
    elif command=="X":
        break
    else:
        print("Unkown command !?? Try again !")
