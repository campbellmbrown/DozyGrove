%% Setup
clear;clc;

prefix = 'grove_';
fileType = '.png';
barrierFilesToRead = ["dark_green_tree_1","dark_green_tree_2", ...
    "dark_green_tree_3","dark_green_tree_4","rock_1","rock_2", ...
    "fallen_log"];
decorationFilesToRead = ["patch"];

%% Formatting barriers

JSONstr = '{';

JSONstr = strcat(JSONstr, '"locationName":"The Grove",');
JSONstr = strcat(JSONstr, '"height":21,');
JSONstr = strcat(JSONstr, '"width":30,');
JSONstr = strcat(JSONstr, '"id":0,');
JSONstr = strcat(JSONstr, GetTileFormatted('barriers', barrierFilesToRead, prefix, fileType));
JSONstr = strcat(JSONstr, ',');
JSONstr = strcat(JSONstr, GetTileFormatted('decorations', decorationFilesToRead, prefix, fileType));
JSONstr = strcat(JSONstr, '}');

disp(JSONstr);
