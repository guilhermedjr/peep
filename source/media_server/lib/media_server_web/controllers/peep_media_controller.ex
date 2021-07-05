defmodule MediaServerWeb.PeepMediaController do
  use MediaServerWeb, :controller

  alias MediaServer.PeepMediaContent
  alias MediaServer.PeepMediaContent.PeepMedia

  action_fallback MediaServerWeb.FallbackController

  # def index(conn, _params) do
  #   peep_media = PeepMediaContent.list_peep_media()
  #   render(conn, "index.json", peep_media: peep_media)
  # end

  # def create(conn, %{"peep_media" => peep_media_params}) do
  #   with {:ok, %PeepMedia{} = peep_media} <- PeepMediaContent.create_peep_media(peep_media_params) do
  #     conn
  #     |> put_status(:created)
  #     |> put_resp_header("location", Routes.peep_media_path(conn, :show, peep_media))
  #     |> render("show.json", peep_media: peep_media)
  #   end
  # end

  # def show(conn, %{"id" => id}) do
  #   peep_media = PeepMediaContent.get_peep_media!(id)
  #   render(conn, "show.json", peep_media: peep_media)
  # end

  # def update(conn, %{"id" => id, "peep_media" => peep_media_params}) do
  #   peep_media = PeepMediaContent.get_peep_media!(id)

  #   with {:ok, %PeepMedia{} = peep_media} <- PeepMediaContent.update_peep_media(peep_media, peep_media_params) do
  #     render(conn, "show.json", peep_media: peep_media)
  #   end
  # end

  # def delete(conn, %{"id" => id}) do
  #   peep_media = PeepMediaContent.get_peep_media!(id)

  #   with {:ok, %PeepMedia{}} <- PeepMediaContent.delete_peep_media(peep_media) do
  #     send_resp(conn, :no_content, "")
  #   end
  # end
end
