function[JSONstr] = GetTileFormatted(tileType, filesToRead, prefix, fileType)

% reading barriers
JSONstr = strcat('"', tileType, '":[');
for b = 1:length(filesToRead)
    % Adding the name of the barrier type
    JSONstr = strcat(JSONstr, '{"type":"', filesToRead(b), ...
        '","positions":');
    
    JSONstr = strcat(JSONstr, FormListFromImage(filesToRead(b), prefix, fileType));

    % Adding the closing bracket for the type
    JSONstr = strcat(JSONstr, '}');
    % Add a new comma if it is not the last type
    if (b ~= length(filesToRead))
       JSONstr = strcat(JSONstr, ',');
    end
end

JSONstr = strcat(JSONstr, ']');

end