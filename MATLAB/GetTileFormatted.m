function[JSONstr] = GetTileFormatted(tileType, filesToRead, prefix, fileType)

% reading barriers
JSONstr = strcat('"', tileType, '":[');
for b = 1:length(filesToRead)
    % Adding the name of the barrier type
    JSONstr = strcat(JSONstr, '{"type":"', filesToRead(b), ...
        '","positions":[');
    % Reading the image
    img = imread(strcat(prefix, filesToRead(b), fileType));
    % Reading the positions of all black pixels in the image
    idx = 1;
    for i = 1:size(img, 1)
        for j = 1:size(img, 2)
            if i > 1 || j > 1
                
            end
            if img(i, j) == 1
                positions(idx, :) = [j - 1, i - 1];
                % Adding each position
                JSONstr = strcat(JSONstr, '[', num2str(i - 1), ...
                    ',', num2str(j - 1), '],');
                idx = idx + 1;
            end
        end
    end
    % Removing the last comma
    JSONstr = strip(JSONstr, 'right', ',');
    % Adding the closing bracket for the type
    JSONstr = strcat(JSONstr, ']}');
    % Add a new comma if it is not the last type
    if (b ~= length(filesToRead))
       JSONstr = strcat(JSONstr, ',');
    end
end

JSONstr = strcat(JSONstr, ']');

end