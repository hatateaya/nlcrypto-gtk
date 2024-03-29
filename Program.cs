/*
    Copyright(c) 2019-2021 Muhua<https://github.com/muhua-usnnrqffjcqv/>.

    This file is part of nlcryptoGtk.

    nlcryptoGtk is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    nlcryptoGtk is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with nlcryptoGtk.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using Gtk;

namespace NlCryptoGtk
{
    static class Program
    {
        /*
         * Todo: 多平台发布
         * Todo: 边角修改
         * 
         */
        public static Application App;
        public static Window Win;
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();
        
            App = new Application("com.github.muhua.nlCryptoGtk", GLib.ApplicationFlags.None);
            App.Register(GLib.Cancellable.Current);

            Win = new MainWindow();
            App.AddWindow(Win);
            Win.Resizable = false;

            Win.ShowAll();
            
            WriteIni();
            Application.Run();
        }

        public static void WriteIni()
        {
            string text = @"
[deCode]
ab=A
ad=B
an=C
at=D
de=E
do=F
eo=G
et=H
ex=I
in=J
is=K
ne=L
ob=M
si=N
ut=O
le=P
la=Q
ago=R
aio=S
amo=T
aut=U
cum=V
cur=W
diu=X
duo=Y
ego=Z
fio=a
hic=b
huc=c
iam=d
ibi=e
ita=f
ius=g
lex=h
nam=i
non=j
nos=k
nox=l
num=m
per=n
pro=o
qua=p
que=q
qui=r
quo=s
res=t
rex=u
rus=v
sed=w
sic=x
sto=y
sub=z
sui=0
sum=1
tam=2
tot=3
tum=4
ubi=5
vel=6
vir=7
vis=8
vix=9
vos=+
alo=/
xd='
aliquis=A
alter=B
annus=C
ante=D
appello=E
aqua=F
atque=G
bellum=H
consul=I
capio=J
credo=K
dico=L
deus=M
deinde=N
dominus=O
domus=P
enim=Q
etiam=R
gens=S
gero=T
igitur=U
illic=V
homo=W
ille=X
inquam=Y
intellego=Z
indicium=a
liber=b
longus=c
manus=d
meus=e
natura=f
nemo=g
nullus=h
nunc=i
oculus=j
omnis=k
opus=l
pars=m
parvus=n
pater=o
peto=p
pono=q
potis=r
primus=s
prope=t
prior=u
propter=v
quin=w
quoque=x
ratio=y
servus=z
tandem=0
trans=1
umquam=2
unde=3
unus=4
usque=5
uter=6
utor=7
verbum=8
vero=9
vita=+
vivo=/
volo='
[enCodeA]
A=ab
B=ad
C=an
D=at
E=de
F=do
G=eo
H=et
I=ex
J=in
K=is
L=ne
M=ob
N=si
O=ut
P=le
Q=la
R=ago
S=aio
T=amo
U=aut
V=cum
W=cur
X=diu
Y=duo
Z=ego
aa=fio
bb=hic
cc=huc
dd=iam
ee=ibi
ff=ita
gg=ius
hh=lex
ii=nam
jj=non
kk=nos
ll=nox
mm=num
nn=per
oo=pro
pp=qua
qq=que
rr=qui
ss=quo
tt=res
uu=rex
vv=rus
ww=sed
xx=sic
yy=sto
zz=sub
0=sui
1=sum
2=tam
3=tot
4=tum
5=ubi
6=vel
7=vir
8=vis
9=vix
+=vos
/=alo
'=XD
[enCodeB]
A=aliquis
B=alter
C=annus
D=ante
E=appello
F=aqua
G=atque
H=bellum
I=consul
J=capio
K=credo
L=dico
M=deus
N=deinde
O=dominus
P=domus
Q=enim
R=etiam
S=gens
T=gero
U=igitur
V=illic
W=homo
X=ille
Y=inquam
Z=intellego
aa=indicium
bb=liber
cc=longus
dd=manus
ee=meus
ff=natura
gg=nemo
hh=nullus
ii=nunc
jj=oculus
kk=omnis
ll=opus
mm=pars
nn=parvus
oo=pater
pp=peto
qq=pono
rr=potis
ss=primus
tt=prope
uu=prior
vv=propter
ww=quin
xx=quoque
yy=ratio
zz=servus
0=tandem
1=trans
2=umquam
3=unde
4=unus
5=usque
6=uter
7=utor
8=verbum
9=vero
+=vita
/=vivo
'=volo
";
            System.IO.File.WriteAllText(System.IO.Path.GetTempPath()+"nlcryptocode.ini", text);
        }
    }
}
