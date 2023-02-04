a=load('.\f6.star.3.diversity.txt');
b=load('.\f6.ring.3.diversity.txt');
c=load('.\f6.fourClusters.3.diversity.txt');
d=load('.\f6.vonNeumann.3.diversity.txt');
e=load('.\f6.socialStar.3.diversity.txt');
f=load('.\f6.socialRing.3.diversity.txt');
g=load('.\f6.cognitive.3.diversity.txt');

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