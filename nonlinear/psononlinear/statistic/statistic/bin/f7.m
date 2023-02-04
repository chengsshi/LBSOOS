a=load('.\f7.star.2.diversity.txt');
b=load('.\f7.ring.2.diversity.txt');
c=load('.\f7.fourClusters.2.diversity.txt');
d=load('.\f7.vonNeumann.2.diversity.txt');
e=load('.\f7.socialStar.2.diversity.txt');
f=load('.\f7.socialRing.2.diversity.txt');
g=load('.\f7.cognitive.2.diversity.txt');

semilogy(a, '-.b');
hold on
semilogy(b, '-r');
semilogy(c, '--k');
semilogy(d, '--g');
%semilogy(e, '-c');
semilogy(f, '-k');
semilogy(g, '--r');

%fontsize = legend('star', 'ring', 'fourClusters', 'vonNeumann', 'socialStar', 'socialRing', 'cognition',0);
fontsize = legend('star', 'ring', 'fourClusters', 'vonNeumann', 'socialRing', 'cognition',0);

set(fontsize, 'FontSize', 14);