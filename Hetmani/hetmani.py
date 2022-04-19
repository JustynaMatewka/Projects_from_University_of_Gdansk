import random

plansza = [ [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] , [" "," "," "," "," "," "," "," "] ]

def planszaa(plansza) :

    q = 1
    h = random.randint( 1 , 5 )
    
    global hetmani 
    global pionek_a
    global pionek_b
    hetmani = []

    pionek_a = random.randint( 0 , 7 ) 
    pionek_b = random.randint( 0 , 7 ) 
    plansza[ pionek_a ][ pionek_b ] = "P"

    for k in range( 0 , h ):

        hetmani.append( [ random.randint( 0 , 7 ) , random.randint( 0 , 7 ) ] )
    
        while hetmani[ -1 ][ 0 ] == pionek_a & hetmani[ -1 ][ 0 ] == pionek_b :
            hetmani.remove( hetmani[ -1 ] )
            hetmani.append( [ random.randint( 0 , 7 ) , random.randint( 0 , 7 ) ] )

        plansza[ hetmani[ -1 ][ 0 ] ][ hetmani[ -1 ][ 1 ] ] = "H"

    print( "\n\033[32;1m      1    2    3    4    5    6    7    8\033[0m \n" )

    for x in plansza:
        print( "\033[32;1m" , q , "\033[0m" , x , "\033[32;1m" , q , "\033[0m" , "\n" )
        q += 1

    print( "\033[32;1m      1    2    3    4    5    6    7    8\033[0m \n" )


def hetman() :

    print( "\nCzy pionek zostanie zbity przez, któregoś z hetmanów? \n" )

    n = 0

    for x in range( 0 , len( hetmani ) ) :
        if pionek_a == hetmani[ x ][ 0 ] :
            print( "\033[35;1mBije hetman: " , hetmani[ x ][ 0 ] + 1 , hetmani[ x ][ 1 ] + 1 , "\033[0m" )
            n += 1
        elif pionek_b == hetmani[ x ][ 1 ] :
            print( "\033[35;1mBije hetman: " , hetmani[ x ][ 0 ] + 1 , hetmani[ x ][ 1 ] + 1 , "\033[0m")
            n += 1
        else :
            p = int( hetmani[ x ][ 0 ] )
            q = int( hetmani[ x ][ 1 ] )

            while p >= 0 & q <= 7 : #Skos gora w prawo 
                if ( p == pionek_a) & ( q == pionek_b) :
                    print( "\033[35;1mBije hetman: " , hetmani[ x ][ 0 ] + 1 , hetmani[ x ][ 1 ] + 1 , "\033[0m")
                    n += 1
                p -= 1 
                q += 1
            
            p = int( hetmani[ x ][ 0 ] )
            q = int( hetmani[ x ][ 1 ] )

            while p >= 0 & q >= 0 : #Skos gora w lewo
                if ( p == pionek_a) & ( q == pionek_b) :
                    print( "\033[35;1mBije hetman: " , hetmani[ x ][ 0 ] + 1 , hetmani[ x ][ 1 ] + 1 , "\033[0m")
                    n += 1
                p -= 1 
                q -= 1

            p = int( hetmani[ x ][ 0 ] )
            q = int( hetmani[ x ][ 1 ] )

            while p <= 7 & q >= 0 : #Skos dol lewo
                if ( p == pionek_a) & ( q == pionek_b) :
                    print( "\033[35;1mBije hetman: " , hetmani[ x ][ 0 ] + 1 , hetmani[ x ][ 1 ] + 1 , "\033[0m")
                    n += 1
                p += 1 
                q -= 1
            
            p = int( hetmani[ x ][ 0 ] )
            q = int( hetmani[ x ][ 1 ] )

            while p <= 7 & q <= 7 : # Skos dol prawo
                if ( p == pionek_a) & ( q == pionek_b) :
                    print( "\033[35;1mBije hetman: " , hetmani[ x ][ 0 ] + 1 , hetmani[ x ][ 1 ] + 1 , "\033[0m")
                    n += 1
                p += 1 
                q += 1
            
            p = int( hetmani[ x ][ 0 ] )
            q = int( hetmani[ x ][ 1 ] )

    if n == 0 :    
        print( "\033[35;1mPionek NIE zostanie zbity \033[0m" )
    
    print( "\n" )
        

def nowy_pionek() :
    p_w = 0
    p_k = 0

    for x in range( 0 , len( plansza ) ) :
        for q in range( 0 , len( plansza[ x ] ) ) :
            if plansza[ x ][ q ] == "P" :
                p_w = x
                p_k = q

    print("\n\033[35;1mUsuwam pionka z pola: " , p_w+1 , p_k+1 , "\033[0m" )

    plansza[ p_w ].pop( p_k )
    plansza[ p_w ].insert( p_k , " ")
    p_w = random.randint( 0 , 7 ) 
    p_k = random.randint( 0 , 7 )
    plansza[ p_w ].pop( p_k )
    plansza[ p_w ].insert( p_k , "P")

    print("\n\033[35;1mNowa pozycja pionka to: " , p_w+1 , p_k+1 , "\n" , "\033[0m" )

    global pionek_a 
    pionek_a = p_w
    global pionek_b
    pionek_b = p_k
    

def usun_hetmana() :

    w = input( "\nPodaj wiersz hetmana do usunięcia: \n" )
    k = input( "Podaj kolumny hetmana do usunięcia: \n" )
    h = [ int( w ) - 1 , int( k ) - 1 ]
    
    for x in range( 0 , len( hetmani ) ) :
        if (int( hetmani[ x ][ 0 ] ) == h[ 0 ]) & (int( hetmani[ x ][ 1 ] ) == h[ 1 ]) :

            print( "\n\033[35;1mUsuwam hetmana z pola: " , h[ 0 ]+1 , h[ 1 ]+1 , "\n" , "\033[0m" )
            plansza[ h[0] ].pop( h[1] )
            plansza[ h[0] ].insert( h[1], " ")


num = 9
planszaa(plansza)
hetman()


while num != 6 :
    
    num = int(input( "Wybierz opcję dodatkową: \n- 0 : wylosowanie nowej pozycji dla pionka z pozostawieniem pierwotnego układu hetmanów\n- 1 : usunięcie dowolnego hetmana (wskazanie jego pozycji)\n- 2 : ponowna weryfikacja bicia po ustaleniu zmian\n- 3 : wyświetl planszę\n- 6 : koniec\n" ))
    
    if num == 0 : 
        nowy_pionek() 

    if num == 1 : 
        usun_hetmana() 

    if num == 2 :
        hetman() 

    if num == 3 :

        q = 1
        print( "\n\033[32;1m      1    2    3    4    5    6    7    8\033[0m \n" )

        for x in plansza:
            print( "\033[32;1m" , q , "\033[0m" , x , "\033[32;1m" , q , "\033[0m" , "\n" )
            q += 1

        print( "\033[32;1m      1    2    3    4    5    6    7    8\033[0m \n" )