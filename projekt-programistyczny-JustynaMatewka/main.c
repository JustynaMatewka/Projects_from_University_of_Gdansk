#include <stdio.h>
#include <stdlib.h>
char plansza[6][7],gracz1,gracz2,ruch,cofnij,imie1[99],imie2[99];
int wybor;
int stworz_plansze(char plansza[6][7]){
    int i,j;
    for(i=0;i<6;i++){
        for(j=0;j<7;j++){
            plansza[i][j]='*';
        }
    }
    return 0;
}
int wyswietl_plansze(char plansza[6][7]){
    int i,j;
    printf("\n");
    for(i=0;i<6;i++){
        printf("| ");
        for(j=0;j<7;j++){
            if(plansza[i][j]=='O'){
                printf("\033[31;1m%c\033[0m | ",plansza[i][j]);
            }else if(plansza[i][j]=='X'){
                printf("\033[32;1m%c\033[0m | ",plansza[i][j]);
            }else{
                printf("\033[30;1m%c\033[0m | ",plansza[i][j]);
            }
        }
        printf("\n-----------------------------\n");
    }
    j=1;
    printf("| ");
    for(i=0;i<7;i++){
        printf("\033[35;1m%i\033[0m | ",j++);
    }
    printf("\n-----------------------------\n\n");
    return 0;
}
int sprawdz_kolumne(char plansza[6][7],int wybor){
    int i,o=0;
    for(i=5;i>=0;i--){
        if(plansza[i][wybor-1]=='X'||plansza[i][wybor-1]=='O'){
            o++;
        }
    }
    if(o==6){
        return 3;
    }
    return 0;
}
int sprawdz_plansze(char plansza[6][7]){
    int i,j,w=0;
    for(i=0;i<6;i++){
        for(j=0;j<7;j++){
            if(plansza[i][j]=='X'||plansza[i][j]=='O'){
                w++;
            }
        }
    }
    return w;
}
int wpisz(char plansza[6][7],int wybor,char ruch){
    int i=5;
    while(i>=0){
        if(plansza[i][wybor-1]=='X'||plansza[i][wybor-1]=='O'){
            i--;
        }else{
            plansza[i][wybor-1]=ruch;
            break;
        }
    }
    return 0;
}
int wygrana_pionowo(char plansza[6][7]){
    int i,o;
    for(o=0;o<7;o++){
        for(i=5;i>2;i--){
            if(plansza[i][o]=='X'&&plansza[i-1][o]=='X'&&plansza[i-2][o]=='X'&&plansza[i-3][o]=='X'){
                return 5;
            }
            if(plansza[i][o]=='O'&&plansza[i-1][o]=='O'&&plansza[i-2][o]=='O'&&plansza[i-3][o]=='O'){
                return 5;
            }
        }
    }
    return 0;
}
int wygrana_poziomo(char plansza[6][7]){
    int i,o;
    for(o=0;o<4;o++){
        for(i=0;i<6;i++){
            if(plansza[i][o]=='X'&&plansza[i][o+1]=='X'&&plansza[i][o+2]=='X'&&plansza[i][o+3]=='X'){
                return 5;
            }
            if(plansza[i][o]=='O'&&plansza[i][o+1]=='O'&&plansza[i][o+2]=='O'&&plansza[i][o+3]=='O'){
                return 5;
            }
        }
    }
    return 0;

}
int wygrana_skos_1(char plansza[6][7]){
    int i,o;
    for(o=0;o<7;o++){
        for(i=5;i>2;i--){
            if(plansza[i][o]=='X'&&plansza[i-1][o+1]=='X'&&plansza[i-2][o+2]=='X'&&plansza[i-3][o+3]=='X'){
                return 5;
            }
            if(plansza[i][o]=='O'&&plansza[i-1][o+1]=='O'&&plansza[i-2][o+2]=='O'&&plansza[i-3][o+3]=='O'){
                return 5;
            }
        }
    }
    return 0;
}
int wygrana_skos_2(char plansza[6][7]){
    int i,o;
    for(o=6;o>=0;o--){
        for(i=5;i>2;i--){
            if(plansza[i][o]=='X'&&plansza[i-1][o-1]=='X'&&plansza[i-2][o-2]=='X'&&plansza[i-3][o-3]=='X'){
                return 5;
            }
            if(plansza[i][o]=='O'&&plansza[i-1][o-1]=='O'&&plansza[i-2][o-2]=='O'&&plansza[i-3][o-3]=='O'){
                return 5;
            }
        }
    }
    return 0;
}
int cofnij_ruch_1(char plansza[6][7],int wybor){
    int i=5;
    while(i>=0){
        if(plansza[i][wybor-1]=='X'||plansza[i][wybor-1]=='O'){
            i--;
        }else{
            plansza[i+1][wybor-1]='*';
            printf("Ruch zostal cofniety");
            wyswietl_plansze(plansza);
            printf("Ruch gracza pierwszego (%c)\nPodaj wybrana kolumne: ",gracz1);
            ruch=gracz1;
            scanf("%i",&wybor);
            while(sprawdz_kolumne(plansza,wybor)==3){
                printf("Wybierz inna kolumne, ta jest juz wypelniona: ");
                scanf("%i",&wybor);
            }
            wpisz(plansza,wybor,ruch);
            wyswietl_plansze(plansza);
            if(wygrana_pionowo(plansza)==5||wygrana_poziomo(plansza)==5||wygrana_skos_1(plansza)==5||wygrana_skos_2(plansza)==5){
                printf("\n*\nWYGRANA gracza \033[32;1mzielonego (%c)\033[0m\n*\n",ruch);
                break;
            }
            break;
        }
    }
    return 0;
        
}
int cofnij_ruch_2(char plansza[6][7],int wybor){
    int i=5;
    while(i>=0){
        if(plansza[i][wybor-1]=='X'||plansza[i][wybor-1]=='O'){
            i--;
        }else{
            plansza[i+1][wybor-1]='*';
            printf("Ruch zostal cofniety");
            wyswietl_plansze(plansza);
            printf("Ruch gracza pierwszego (%c)\nPodaj wybrana kolumne: ",gracz2);
            ruch=gracz2;
            scanf("%i",&wybor);
            while(sprawdz_kolumne(plansza,wybor)==3){
                printf("Wybierz inna kolumne, ta jest juz wypelniona: ");
                scanf("%i",&wybor);
            }
            wpisz(plansza,wybor,ruch);
            wyswietl_plansze(plansza);
            if(wygrana_pionowo(plansza)==5||wygrana_poziomo(plansza)==5||wygrana_skos_1(plansza)==5||wygrana_skos_2(plansza)==5){
                printf("\n*\nWYGRANA gracza \033[32;1mzielonego (%c)\033[0m\n*\n",ruch);
                break;
            }
            break;
        }
    }
    return 0;
        
}
int imiona(char gracz1,char gracz2){
    FILE *out;
    out = fopen("gracze.txt","a");
    printf("Podaj imie pierwszego gracza: ");
    gets(imie1);
    gets(imie1);
    fprintf(out,"\n%s",imie1);
    printf("Podaj imie drugiego gracza: ");
    gets(imie2);
    fprintf(out,"\n%s",imie2);
    fclose(out);

    return 0;
}
int zapis_gry(char plansza[6][7],char imie1[99],char imie2[99],char gracz1,char gracz2,char ruch){
    int i,j;
    FILE *out;
    out = fopen("rozgrywka.txt","a");
    fprintf(out,"\n");
    fprintf(out,"Rozgrywka graczy: %s i %s\n",imie1,imie2);
    if(gracz1==ruch){
        fprintf(out,"Wygrana gracza: %s\n",imie1);
    }else{
        fprintf(out,"Wygrana gracza: %s\n",imie1);
    }
    fprintf(out,"\n");
    for(i=0;i<6;i++){
        fprintf(out,"| ");
        for(j=0;j<7;j++){
            if(plansza[i][j]=='O'){
                fprintf(out,"%c | ",plansza[i][j]);
            }else if(plansza[i][j]=='X'){
                fprintf(out,"%c | ",plansza[i][j]);
            }else{
                fprintf(out,"%c | ",plansza[i][j]);
            }
        }
        fprintf(out,"\n-----------------------------\n");
    }
    j=1;
    fprintf(out,"| ");
    for(i=0;i<7;i++){
        fprintf(out,"%i | ",j++);
    }
    fprintf(out,"\n-----------------------------\n\n");

    return 0;
    
}
int zapis_gry_remis(char plansza[6][7],char imie1[99],char imie2[99],char gracz1,char gracz2,char ruch){
    int i,j;
    FILE *out;
    out = fopen("rozgrywka_remis.txt","a");
    fprintf(out,"\n");
    fprintf(out,"Remis graczy: %s i %s\n",imie1,imie2);
    fprintf(out,"\n");
    for(i=0;i<6;i++){
        fprintf(out,"| ");
        for(j=0;j<7;j++){
            if(plansza[i][j]=='O'){
                fprintf(out,"%c | ",plansza[i][j]);
            }else if(plansza[i][j]=='X'){
                fprintf(out,"%c | ",plansza[i][j]);
            }else{
                fprintf(out,"%c | ",plansza[i][j]);
            }
        }
        fprintf(out,"\n-----------------------------\n");
    }
    j=1;
    fprintf(out,"| ");
    for(i=0;i<7;i++){
        fprintf(out,"%i | ",j++);
    }
    fprintf(out,"\n-----------------------------\n\n");

    return 0;
    
}

int main(){
    stworz_plansze(plansza);
    
    //Wybor koloru gracza 1
    printf("\nWybierz kolor:\n\033[31;1mczerwony (O)\033[0m\n\033[32;1mzielony (X)\033[0m\n");
    scanf("%c",&gracz1);
    if(gracz1=='X'){
        gracz2='O';
    }else if(gracz1=='O'){
        gracz2='X';
    }else{
        printf("Podales niepoprawny kolor");
        return 0;
    }
    imiona(gracz1,gracz2);
    
    wyswietl_plansze(plansza);
    while(sprawdz_plansze(plansza)!=42){
        printf("Ruch gracza pierwszego (%c)\nPodaj wybrana kolumne: ",gracz1);
        ruch=gracz1;
        scanf("%i",&wybor);
        while(wybor<1||wybor>7){
            printf("Podales wartosc spoza zakresu planszy Podaj numer kolumny: ");
            scanf("%i",&wybor);
        }
        while(sprawdz_kolumne(plansza,wybor)==3){
            printf("Wybierz inna kolumne, ta jest juz wypelniona: ");
            scanf("%i",&wybor);
            while(wybor<1||wybor>7){
                printf("Podales wartosc spoza zakresu planszy Podaj numer kolumny: ");
                scanf("%i",&wybor);
            }
        }
        wpisz(plansza,wybor,ruch);
        wyswietl_plansze(plansza);
        if(wygrana_pionowo(plansza)==5||wygrana_poziomo(plansza)==5||wygrana_skos_1(plansza)==5||wygrana_skos_2(plansza)==5){
            if(ruch=='X'){printf("\n*\nWYGRANA gracza \033[32;1mzielonego (%c)\033[0m\n*\n",ruch);}
            else{printf("\n*\nWYGRANA gracza \033[31;1mczerwonego (%c)\033[0m\n*\n",ruch);}
            printf("Chcesz zapisac gre? (T/N)\n");
            char opcja;
            scanf("%c",&opcja);
            scanf("%c",&opcja);
            if(opcja=='T'||opcja=='t'){
                zapis_gry(plansza,imie1,imie2,gracz1,gracz2,ruch);
            }
            break;
        }
        printf("Cofnac ruch? (T/N)\n");
        scanf("%c",&cofnij);
        scanf("%c",&cofnij);
        if(cofnij=='t'||cofnij=='T'){
            cofnij_ruch_1(plansza,wybor);
        }
        
        printf("Ruch gracza drugiego (%c)\nPodaj wybrana kolumne: ",gracz2);
        ruch=gracz2;
        scanf("%i",&wybor);
        while(wybor<1||wybor>7){
            printf("Podales wartosc spoza zakresu planszy Podaj numer kolumny: ");
            scanf("%i",&wybor);
        }
        while(sprawdz_kolumne(plansza,wybor)==3){
            printf("Wybierz inna kolumne, ta jest juz wypelniona: ");
            scanf("%i",&wybor);
            while(wybor<1||wybor>7){
                printf("Podales wartosc spoza zakresu planszy Podaj numer kolumny: ");
                scanf("%i",&wybor);
            }
        }
        wpisz(plansza,wybor,ruch);
        wyswietl_plansze(plansza);
        if(wygrana_pionowo(plansza)==5||wygrana_poziomo(plansza)==5||wygrana_skos_1(plansza)==5||wygrana_skos_2(plansza)==5){
            if(ruch=='X'){printf("\n*\nWYGRANA gracza \033[32;1mzielonego (%c)\033[0m\n*\n",ruch);}
            else{printf("\n*\nWYGRANA gracza \033[31;1mczerwonego (%c)\033[0m\n*\n",ruch);}
            wyswietl_plansze(plansza);
            printf("Chcesz zapisac gre? (T/N)\n");
            char opcja;
            scanf("%c",&opcja);
            scanf("%c",&opcja);
            if(opcja=='T'||opcja=='t'){
                zapis_gry(plansza,imie1,imie2,gracz1,gracz2,ruch);
            }
            break;
        }
        printf("Cofnac ruch? (T/N)\n");
        scanf("%c",&cofnij);
        scanf("%c",&cofnij);
        if(cofnij=='t'||cofnij=='T'){
            cofnij_ruch_2(plansza,wybor);
        }
    }
    if(sprawdz_plansze(plansza)==42){
        printf("Brak wolnych pol\nREMIS\n");
        printf("Chcesz zapisac gre? (T/N)\n");
            char opcja;
            scanf("%c",&opcja);
            scanf("%c",&opcja);
            if(opcja=='T'||opcja=='t'){
                zapis_gry_remis(plansza,imie1,imie2,gracz1,gracz2,ruch);
            }
    }
    printf("koniec");
    
    return 0;
}